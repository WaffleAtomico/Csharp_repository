// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace almacenist.encription
{
    public class Encript
    {
         public byte[] AES(string PWD){
            byte[] key = new byte[16]; // 16 bytes para AES-128
            byte[] iv = new byte[16]; // IV debe ser del mismo tamaño que la clave

            using (Aes aesAlg = Aes.Create()) //se crea el objeto aesAlg
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                // Crear un encriptador para AES
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                // Crear un flujo de memoria para escribir los datos encriptados
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Crear un flujo de cifrado para escribir los datos encriptados
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Escribir los datos encriptados en el flujo
                            swEncrypt.Write(PWD);
                        }
                    }
                    // Obtener los datos encriptados como un arreglo de bytes
                    byte[] encryptedBytes = msEncrypt.ToArray();
                    return encryptedBytes; //para pasar el dato como corresponde y es
                }
            }
           
         }
    }
}


// using System;
// using System.IO;
// using System.Security.Cryptography;
// using System.Text;

// class AesEncryptionExample
// {
//     static void Main()
//     {
//         string originalText = "Este es el texto que quiero encriptar.";

//         // Generar una clave y un IV (Initialization Vector) aleatorios para AES-128
//             }
// }
