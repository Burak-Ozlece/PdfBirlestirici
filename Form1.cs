using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace PdfBirlestirici
{
    public partial class Form1 : Form
    {
        // Kullanıcının seçtiği klasör yolu bu değişkende tutulur
        private string selectedFolder;

        public Form1()
        {
            InitializeComponent();
        }

        // "Klasör Seç" butonuna tıklanıldığında çalışan metod
        private void button1_Click(object sender, EventArgs e)
        {
            // Klasör seçme penceresini aç
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                // Kullanıcı klasör seçtiyse işlem yap
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    selectedFolder = fbd.SelectedPath; // Seçilen klasörü sakla
                    textBox1.Text = selectedFolder;    // TextBox'a yolu yaz
                    listBox1.Items.Clear();            // Önceki verileri temizle

                    // 📄 Sadece PDF dosyalarını seç ve "Birleştirilmiş Pdf.pdf" dosyasını hariç tut
                    string[] pdfFiles = Directory.GetFiles(selectedFolder, "*.pdf")
                                                 .Where(x => Path.GetFileName(x) != "Birleştirilmiş Pdf.pdf")
                                                 .Select(f => Path.GetFileName(f)) // Sadece dosya adını al
                                                 .OrderBy(f => f)                  // Alfabetik sırala
                                                 .ToArray();

                    // Liste kutusuna PDF dosya adlarını ekle
                    listBox1.Items.AddRange(pdfFiles);

                    // Label'a toplam dosya sayısını yaz
                    var count = listBox1.Items.Count.ToString();
                    label2.Text = "Toplam PDF dosya sayısı: " + count;

                    // Progress bar başlangıç değeri ve maksimumu ayarla
                    progressBar1.Value = 0;
                    progressBar1.Maximum = pdfFiles.Length; // Toplam dosya sayısı kadar ilerleme çubuğu ayarla
                }
            }
        }

        // "PDF'leri Birleştir" butonuna tıklanıldığında çalışan metod
        private void button2_Click(object sender, EventArgs e)
        {
            // Birleştirilmiş dosyanın hedef yolu
            string outputFilePath = Path.Combine(selectedFolder, "Birleştirilmiş Pdf.pdf");

            // ListBox'taki PDF dosyaları alınır
            var pdfFiles = listBox1.Items;

            // Eğer daha önce oluşturulmuş bir çıktı varsa silinir
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }

            try
            {
                // Yeni bir PDF dosyası oluşturmak için yazıcı başlatılır
                using (PdfDocument mergedPdf = new PdfDocument(new PdfWriter(outputFilePath)))
                {
                    // PdfMerger ile birleştirme işlemi yapılır
                    PdfMerger merger = new PdfMerger(mergedPdf);

                    // Listedeki her PDF dosyasını sırayla birleştir
                    foreach (string file in pdfFiles)
                    {
                        string filePath = Path.Combine(selectedFolder, file); // Tam dosya yolu
                        if (IsFileLocked(filePath))
                        {
                            MessageBox.Show($"'{file}' şu anda kullanımda. Lütfen kapatıp tekrar deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        using (PdfDocument pdf = new PdfDocument(new PdfReader(filePath)))
                        {
                            // PDF'nin tüm sayfalarını birleştir
                            merger.Merge(pdf, 1, pdf.GetNumberOfPages());
                        }

                        // Her dosyadan sonra progress bar'ı bir adım artır
                        progressBar1.PerformStep();
                    }

                    // İşlem tamamlandığında kullanıcıya bilgi ver
                    MessageBox.Show("PDF dosyaları başarıyla birleştirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Progress bar'ı tamamen doldur
                    progressBar1.Value = progressBar1.Maximum;

                    // Birleştirme tamamlandıktan sonra klasörü aç
                    Process.Start("explorer.exe", selectedFolder);
                }
            }
            catch (Exception ex)
            {
                string hataMesaji = "PDF birleştirme sırasında bir hata oluştu:\n\n" +
                       ex.Message;

                if (ex.InnerException != null)
                {
                    hataMesaji += "\n\nDetay: " + ex.InnerException.Message;
                }

                MessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    // Dosya kilitli değil
                    return false;
                }
            }
            catch (IOException)
            {
                // Dosya başka bir işlem tarafından kullanılıyor
                return true;
            }
        }
    }
}
