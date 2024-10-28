namespace D
  }
            GetAlbums(testFiles);
            var directories = GetAlbums(testFiles);

            Console.WriteLine("Директории с аудиофайлами:");
            foreach (var dir in directories)
            {
                Console.WriteLine(dir.FullName);
            }
        }

        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            ...
            return files
                .Where(file => file.Extension == ".mp3" || file.Extension == ".wav")
                .Select(file => file.Directory)
                .Distinct()
                .ToList();
        }
    }
}
