using System;
using AfterSchoolClub.Api.Models;

namespace AfterSchoolClub.Api.Features
{
    public static class DigitalAssetExtensions
    {
        public static DigitalAssetDto ToDto(this DigitalAsset digitalAsset)
        {
            return new ()
            {
                DigitalAssetId = digitalAsset.DigitalAssetId
            };
        }
        
    }
}
