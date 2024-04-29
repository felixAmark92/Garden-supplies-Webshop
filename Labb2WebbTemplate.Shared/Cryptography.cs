using System.Security.Cryptography;
using System.Text;

namespace Labb2WebbTemplate.Shared;

public static class Cryptography
{
    public static byte[] CreateSha256Hash(string inputString, byte[] salt)
    {
        using HashAlgorithm algorithm = SHA256.Create();
        return GetHash(inputString, salt, algorithm);
    }
    
    private static byte[] GetHash(string inputString, byte[] salt, HashAlgorithm algorithm)
    {
        var inputBytes = Encoding.UTF8.GetBytes(inputString);
        var saltedInputBytes = inputBytes.Concat(salt).ToArray();
        return algorithm.ComputeHash(saltedInputBytes);
    }
    public static byte[] GenerateSalt()
    {
        var random = RandomNumberGenerator.Create();
        const int maxLength = 32;
        var salt = new byte[maxLength];
    
        random.GetNonZeroBytes(salt);
        return salt;
    }
}