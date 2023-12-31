﻿using System.ComponentModel.DataAnnotations.Schema;
using TransportGlobal.Domain.Entities.TransportContextEntities;
using TransportGlobal.Domain.Enums.TransporterContextEnums;
using TransportGlobal.Domain.SeedWorks;

namespace TransportGlobal.Domain.Entities.TransporterContextEntities
{
    public class VehicleEntity : BaseEntity
    {
        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }

        public CompanyEntity? Company { get; set; }

        public string IdentificationNumber { get; set; }

        public VehicleType Type { get; set; }

        public VehicleStatusType Status { get; set; }

        public ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();

        public ICollection<TransportContractEntity> TransportContracts { get; set; } = new List<TransportContractEntity>();

        public VehicleEntity(int companyID, string identificationNumber, VehicleType type, VehicleStatusType status, bool isDeleted = false)
        {
            CompanyID = companyID;
            IdentificationNumber = identificationNumber;
            Type = type;
            Status = status;
            IsDeleted = isDeleted;
        }
    }
}
