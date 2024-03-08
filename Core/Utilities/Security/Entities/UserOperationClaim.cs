﻿using Core.Entities;

namespace Core.Utilities.Security.Entities;

public class UserOperationClaim:BaseEntity<int>
{
    public Guid UserId { get; set; }   //1
    public int OperationClaimId { get; set; } // 1=>developer
    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
        
    }

    public UserOperationClaim(int id,Guid userId, int operationClaimId):this()
    {
        Id = id;
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}
