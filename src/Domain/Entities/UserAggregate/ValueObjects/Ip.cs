using System.Text.RegularExpressions;
using Ardalis.GuardClauses;

namespace Synword.Domain.Entities.UserAggregate.ValueObjects;

public class Ip
{
    private Ip()
    {
        // required by EF
    }
    
    public Ip(string ip)
    {
        Guard.Against.NullOrEmpty(ip, nameof(ip));
        
        Regex validIp = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");

#if !DEBUG
        if (!validIp.IsMatch(ip))
        {
            throw new FormatException($"{ip} is Invalid IP address");
        }
#endif

        Value = ip;
    }
    public string Value { get; private set; }
}
