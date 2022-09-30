using System.Text;
using System.Text.Json;

namespace AsynchronousDemo;

internal class FileAccessDemo
{
    public void ReadFile()
    {
        var path = @"D:\AsyncDemo\read-file.txt";
        var fileInfo = new FileInfo(path);
        var bytes = new byte[fileInfo.Length];

        using var fs = new FileStream(path, FileMode.OpenOrCreate);

        fs.Read(bytes);

        var data = Encoding.UTF8.GetString(bytes);
    }

    public void WriteFile()
    {
        var path = @"D:\AsyncDemo\write-file.txt";
        using var fs = new FileStream(path, FileMode.OpenOrCreate);

        var modelAsString = JsonSerializer.Serialize(new
        {
            FirstName = "Prajwal",
            LastName = "Aradhya"
        });

        var data = Encoding.UTF8.GetBytes(modelAsString); // Json Data

        fs.Write(data);
    }

    public async Task ReadFileAsync()
    {
        var path = @"D:\AsyncDemo\read-file.txt";
        var fileInfo = new FileInfo(path);
        var bytes = new byte[fileInfo.Length];

        using var fs = new FileStream(path, FileMode.OpenOrCreate);
        await fs.ReadAsync(bytes);

        var data = Encoding.UTF8.GetString(bytes);
    }

    public async Task WriteFileAsync()
    {
        var path = @"D:\AsyncDemo\write-file-async.txt";
        using var fs = new FileStream(path, FileMode.OpenOrCreate);

        var modelAsString = JsonSerializer.Serialize(new
        {
            FirstName = "Prajwal",
            LastName = "Aradhya"
        });

        var data = Encoding.UTF8.GetBytes(modelAsString); // Json Data

        await fs.WriteAsync(data);
    }
}
