// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

string dominio;
Console.WriteLine("Ingresa un dominio completo, por ejemplo, en vez de poner solo gmail, poner gmail.com: ");
dominio = Console.ReadLine();
EmailDomainValidator(dominio);

 async static Task<bool> EmailDomainValidator(string dominio = "")
{
    bool esValido = false; 
    try
    {
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();

        process.StandardInput.WriteLine("nslookup -q=mx " + dominio);

        process.StandardInput.Flush();
        process.StandardInput.Close();
        process.WaitForExit();

        var salida = process.StandardOutput.ReadToEnd();
        var encuentro = "MX";
        int i = salida.IndexOf(encuentro);

        if (i > 0)
        {
            esValido = true;
        }
        else
            if (salida.IndexOf("DNS request timed out.") != -1)
        {
            throw new Exception();
        }

        Console.WriteLine(esValido);
        return esValido;
    }
    catch (Exception ex)
    {
        Console.WriteLine(await GetProductAsync("https://www.nslookup.io/api/v1/records", dominio));
        return await GetProductAsync("https://www.nslookup.io/api/v1/records", dominio);
    }
}

static async Task<bool> GetProductAsync(string path, string dominio)
{
    HttpClient client = new HttpClient();
    string res = "";
    bool valid = false;
    string json = JsonConvert.SerializeObject(new { domain = dominio, dnsServer = "google" });
    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

    HttpResponseMessage response = await client.PostAsync(path, httpContent);

    if (response.IsSuccessStatusCode)
    {
        res = await response.Content.ReadAsStringAsync();
    }

    if (res.IndexOf("NOERROR") != -1 || res.IndexOf("charlestonroadregistry") != -1)
    {
        valid = true;
    }

    return valid;
}
    