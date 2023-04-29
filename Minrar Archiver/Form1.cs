using Minrar_Archiver.Entities;
using Minrar_Archiver.Services;
using System.IO.Enumeration;

namespace Minrar_Archiver
{
    public partial class Form1 : Form
    {
        private readonly ArchivingService _archivingService;
        private byte[] fileContent;
        private const long MAX_SIZE_IN_MB = 100;

        public Form1()
        {
            InitializeComponent();
            _archivingService = new ArchivingService();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog { Multiselect = true })
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    var files = opf.FileNames;

                    if (files.Length > 5)
                    {
                        return;
                    }

                    var fileEntities = new List<FileEntity>();

                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        if (!(Util.ConvertByteToMB(fileInfo.Length) >= MAX_SIZE_IN_MB))
                        {
                            var fileEntity = new FileEntity
                            {
                                FileName = Path.GetFileName(file),
                                FileContent = File.ReadAllBytes(file)
                            };
                            fileEntities.Add(fileEntity);
                        }
                    }

                    var archivingResult = _archivingService.Encode(fileEntities);

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "minrar files|*.minrar" })
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(Path.GetFileNameWithoutExtension(saveFileDialog.FileName) + ".minrar", archivingResult);
                        }
                    }
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog { Multiselect = false, Filter = "minrar files|*.minrar" })
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        listView1.Items.Clear();
                        fileContent = File.ReadAllBytes(opf.FileName);

                        if (_archivingService.IsEncrypted(fileContent))
                        {

                        }

                        FileEntity[] files = _archivingService.Decode(fileContent);
                        foreach (var file in files)
                        {
                            listView1.Items.Add(file.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (fileContent == null)
            {
                using (OpenFileDialog opf = new OpenFileDialog { Filter = "minrar files|*.minrar" })
                {
                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                        fileContent = File.ReadAllBytes(opf.FileName);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            using (FolderBrowserDialog saveFileDialog = new FolderBrowserDialog())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var extractedFiles = _archivingService.Decode(fileContent);
                    foreach (var extractedFile in extractedFiles)
                    {
                        File.WriteAllBytes(Path.Combine(saveFileDialog.SelectedPath, extractedFile.FileName), extractedFile.FileContent);
                    }

                    MessageBox.Show("Extracted Successfully");
                }
            }
        }
    }
}