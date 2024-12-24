using System.IO;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Teste.Utilitarios
{
    public static class Util
    {
        public static string CaminhoDriverNavegador() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
