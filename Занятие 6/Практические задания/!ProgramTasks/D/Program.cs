namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FileInfo> testFiles = new List<FileInfo>
            {
                new FileInfo(@"C:\Музыка\Былина\песня1.mp3"),
                new FileInfo(@"C:\Музыка\Плясовая\песня2.wav"),
                new FileInfo(@"C:\Музыка\Былина\песня3.wav"),
                new FileInfo(@"C:\Музыка\Калинушка\песня4.mp3"),
                new FileInfo(@"C:\Музыка\Плясовая\песня5.txt"),
                new FileInfo(@"C:\Документы\Работа\файл.docx"),
                new FileInfo(@"D:\Скачанное\песня6.mp3"),
                new FileInfo(@"D:\Скачанное\песня7.wav"),
                new FileInfo(@"C:\Музыка\Былина\песня8.txt")
            };

            GetAlbums(testFiles);
        }

        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            ...
        }
    }
}