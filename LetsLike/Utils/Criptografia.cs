using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike.Utils
{
    public class Criptografia
    {
        // TODO realizar a criptografia de registros de forma dinâmica
        // exemplo, se ele receber um parâmetro, que seja um parâemtro vindo de qlqr classe
        // ou método

        //private static string Key = "181928hs87ah7hsjGHhY7SU2USJ92ujs"; //usada na encriptação e decriptação
        //private static string IV;

        //public static string Encrypt(string stringToCipher)
        //{
        //    Aes cipher = Aes.Create(); //cria um Aes (cifrador)
        //    cipher.Key = Encoding.UTF8.GetBytes(Key); //passa a chave no encoding

        //    IV = Convert.ToBase64String(cipher.IV); //gera um IV

        //    ICryptoTransform cryptTransform = cipher.CreateEncryptor(); //cria um CryptoTransform

        //    var byteToCipher = Encoding.UTF8.GetBytes(stringToCipher); //transformo o texto em um array de bytes
        //    var cipherText = cryptTransform.TransformFinalBlock(byteToCipher, 0, byteToCipher.Length); //transformo todo o array em crypto

        //    return Convert.ToBase64String(cipherText); //pego o array de bytes encriptado e transformo em string 64
        //}
    }
}
