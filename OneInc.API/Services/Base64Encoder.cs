using System.Text;
using OneInc.API.Interfaces;

namespace OneInc.API.Services;

public class Base64Encoder : IStringEncoder
{
    public string Encode(string value)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    }
}