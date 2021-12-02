using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Utils
{
    public class Descriptografia
    {
        //private readonly ICriptografia _criptografia;
        //public Descriptografia(ICriptografia criptografia)
        //{
        //    _criptografia = criptografia;
        //}

        //public static string Decrypt(string cipherToString)
        //{
        //    Aes cipher = Aes.Create();
        //    cipher.Key = Encoding.UTF8.GetBytes(Key); //passa a chave usada no encrypt reatribuindo-a pq a cada criptografia ela fica diferente, então ela tem que ser reatribuida p/ n dar conflito
        //    cipher.IV = Convert.FromBase64String(IV); //usa o IV p/ desencriptar a palavra

        //    ICryptoTransform cryptoTransform = cipher.CreateDecryptor(); //cria um decriptador, que utiliza a chave e o IV
        //    var cipherBytes = Convert.FromBase64String(cipherToString); //recebo a palavra p/ desencriptar e tiro ela da base 64
        //    var plainText = cryptoTransform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length); //transformo a palavra em um array de bytes

        //    return Encoding.UTF8.GetString(plainText); //transformo o array de bytes na palavra
        //}
    }
}
