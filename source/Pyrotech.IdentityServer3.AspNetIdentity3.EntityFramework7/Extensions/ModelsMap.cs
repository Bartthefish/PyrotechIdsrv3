﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using IdentityServer3.Core.Models;

namespace Pyrotech.IdentityServer3.AspNetIdentity3.EntityFramework7.Extensions
{
    public static class ModelsMap
    {
        static ModelsMap()
        {
            Mapper.CreateMap<Scope, Entities.Scope>(MemberList.Source)
                .ForSourceMember(x => x.Claims, opts => opts.Ignore())
                .ForMember(x => x.ScopeClaims, opts => opts.MapFrom(src => src.Claims.Select(x => x)));
            Mapper.CreateMap<ScopeClaim, Entities.ScopeClaim>(MemberList.Source);

            Mapper.CreateMap<Secret, Entities.ClientSecret>(MemberList.Source);
            Mapper.CreateMap<Client, Entities.Client>(MemberList.Source)
                .ForMember(x => x.UpdateAccessTokenOnRefresh, opt => opt.MapFrom(src => src.UpdateAccessTokenClaimsOnRefresh))
                .ForMember(x => x.AllowAccessToAllGrantTypes, opt => opt.MapFrom(src => src.AllowAccessToAllCustomGrantTypes))
                .ForMember(x => x.AllowedCustomGrantTypes, opt => opt.MapFrom(src => src.AllowedCustomGrantTypes.Select(x => new Entities.ClientCustomGrantType { GrantType = x })))
                .ForMember(x => x.RedirectUris, opt => opt.MapFrom(src => src.RedirectUris.Select(x => new Entities.ClientRedirectUri { Uri = x })))
                .ForMember(x => x.PostLogoutRedirectUris, opt => opt.MapFrom(src => src.PostLogoutRedirectUris.Select(x => new Entities.ClientPostLogoutRedirectUri { Uri = x })))
                .ForMember(x => x.IdentityProviderRestrictions, opt => opt.MapFrom(src => src.IdentityProviderRestrictions.Select(x => new Entities.ClientProviderRestriction { Provider = x })))
                .ForMember(x => x.AllowedScopes, opt => opt.MapFrom(src => src.AllowedScopes.Select(x => new Entities.ClientScope { Scope = x })))
                .ForMember(x => x.AllowedCorsOrigins, opt => opt.MapFrom(src => src.AllowedCorsOrigins.Select(x => new Entities.ClientCorsOrigin { Origin = x })))
                .ForMember(x => x.Claims, opt => opt.MapFrom(src => src.Claims.Select(x => new Entities.ClientClaim { Type = x.Type, Value = x.Value })));
        }

        public static Entities.Scope ToEntity(this Scope s)
        {
            if (s == null)
            {
                return null;
            }
            if (s.Claims == null)
            {
                s.Claims = new List<ScopeClaim>();
            }

            return Mapper.Map<Scope, Entities.Scope>(s);
        }

        public static Entities.Client ToEntity(this Client s)
        {
            if (s == null)
            {
                return null;
            }
            if (s.ClientSecrets == null)
            {
                s.ClientSecrets = new List<Secret>();
            }
            if (s.RedirectUris == null)
            {
                s.RedirectUris = new List<string>();
            }
            if (s.PostLogoutRedirectUris == null)
            {
                s.PostLogoutRedirectUris = new List<string>();
            }
            if (s.AllowedScopes == null)
            {
                s.AllowedScopes = new List<string>();
            }
            if (s.IdentityProviderRestrictions == null)
            {
                s.IdentityProviderRestrictions = new List<string>();
            }
            if (s.Claims == null)
            {
                s.Claims = new List<Claim>();
            }
            if (s.AllowedCustomGrantTypes == null)
            {
                s.AllowedCustomGrantTypes = new List<string>();
            }
            if (s.AllowedCorsOrigins == null)
            {
                s.AllowedCorsOrigins = new List<string>();
            }

            return Mapper.Map<Client, Entities.Client>(s);
        }
    }
}