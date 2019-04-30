using AutoMapper;
using PaymentHistory.API.Models;
using PaymentHistory.Domain.Dtos;

namespace PaymentHistory.API.Mapping
{
    public class PaymentHistoryApiProfile : Profile
    {
        public PaymentHistoryApiProfile()
        {
            CreateMap<PaymentHistoryRequest, CustomerInfoDto>();

            CreateMap<CustomerPaymentsDto, PaymentHistoryResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.MobileNumber));

            CreateMap<TransactionDto, Transaction>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TransactionDate))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencyCode))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString("G")));
        }
    }
}