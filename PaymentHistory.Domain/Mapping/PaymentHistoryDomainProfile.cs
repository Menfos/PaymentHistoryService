using System;
using AutoMapper;
using PaymentHistory.DAL.Entities;
using PaymentHistory.Domain.Dtos;

namespace PaymentHistory.Domain.Mapping
{
    public class PaymentHistoryDomainProfile : Profile
    {
        public PaymentHistoryDomainProfile()
        {
            CreateMap<CustomerEntity, CustomerPaymentsDto>();
            CreateMap<TransactionEntity, TransactionDto>()
                .ForMember(transactionDto => transactionDto.Status,
                    opt => opt.MapFrom(src =>
                        Enum.IsDefined(typeof(TransactionStatus), src.Status)
                            ? Enum.Parse(typeof(TransactionStatus), src.Status)
                            : TransactionStatus.Unknown));
        }
    }
}