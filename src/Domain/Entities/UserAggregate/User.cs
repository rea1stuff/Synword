﻿using Ardalis.GuardClauses;
using Synword.Domain.Entities.PlagiarismCheckAggregate;
using Synword.Domain.Entities.RephraseAggregate;
using Synword.Domain.Entities.UserAggregate.ValueObjects;
using Synword.Domain.Enums;
using Synword.Domain.Interfaces;

namespace Synword.Domain.Entities.UserAggregate;

public class User : BaseEntity<string>, IAggregateRoot
{
    private User()
    {
        // required by EF
    }
    
    public User(string id, Ip ip, List<Role> roles, 
        Coins coins, UsageData usageData)
    {
        Guard.Against.Null(id, nameof(id));
        Guard.Against.Null(ip, nameof(ip));
        Guard.Against.Null(roles, nameof(roles));
        Guard.Against.Null(coins, nameof(coins));
        Guard.Against.Null(usageData, nameof(usageData));
        
        Id = id;
        Ip = ip;
        _roles = roles;
        Coins = coins;
        UsageData = usageData;
    }
    public new string Id { get; private set; }
    public ExternalSignIn? ExternalSignIn { get; private set; }
    public Ip Ip { get; private set; }
    private readonly List<Role> _roles = new();
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();
    public Coins Coins { get; private set; }
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    public UsageData UsageData { get; private set; }
    public List<PlagiarismCheckResult>? PlagiarismCheckHistory { get; private set; }
    public List<RephraseResult>? RephraseHistory { get; private set; }
    public Metadata? Metadata { get; private set; }
    
    public void AddOrder(Order order)
    {
        Guard.Against.Null(order, nameof(order));
        
        _orders.Add(order);
    }

    public void AddExternalSignIn(ExternalSignIn externalSignIn)
    {
        Guard.Against.Null(externalSignIn, nameof(externalSignIn));
        
        if (ExternalSignIn != null)
        {
            throw new Exception("ExternalSignIn already exist");
        }

        ExternalSignIn = externalSignIn;
    }

    public static User CreateDefaultGuest(string id, string ip, DateTime dateTimeNow)
    {
        Guard.Against.NullOrEmpty(nameof(id), id);
        Guard.Against.NullOrEmpty(nameof(ip), ip);
        
        User guest = new User(
            id: id,
            ip: new Ip(ip),
            roles: new List<Role>() { Role.Guest },
            usageData: new UsageData(
                plagiarismCheckCount: 0,
                rephraseCount: 0,
                lastVisitDate: dateTimeNow,
                creationDate: dateTimeNow
            ),
            coins: new Coins(1)
        );

        return guest;
    }
}
