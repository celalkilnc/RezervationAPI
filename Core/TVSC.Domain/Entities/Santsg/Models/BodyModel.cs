﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models
{
    public class BodyModel
    {
        public Body body { get; set; }
        public Header header { get; set; }
    }

    public class Agency
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string registerCode { get; set; }
        public string firmName { get; set; }
        public string licenseNo { get; set; }
        public bool ownAgency { get; set; }
        public int paymentFrom { get; set; }
        public bool useOwnWebSettings { get; set; }
        public bool sendFlightInfoSms { get; set; }
        public int allowUnpaidRes { get; set; }
        public bool aceExport { get; set; }
        public string nationality { get; set; }
        public bool allowNon3DPayments { get; set; }
        public string webSetGrp { get; set; }
        public bool bonusUseSysParam { get; set; }
        public bool bonusUserSeeAgencyW { get; set; }
        public bool bonusUserSeeOwnW { get; set; }
        public bool allowAddCredit { get; set; }
        public bool showAgencyLogoOnB2b { get; set; }
        public bool hideInstallmentTable { get; set; }
        public bool hideAgencyCreditOnWeb { get; set; }
        public bool force2FactorAuth { get; set; }
        public int location { get; set; }
    }

    public class Body
    {
        public string token { get; set; }
        public DateTime expiresOn { get; set; }
        public int tokenId { get; set; }
        public UserInfo userInfo { get; set; }
        public bool loggedInWithMasterKey { get; set; }
    }

    public class Header
    {
        public string requestId { get; set; }
        public bool success { get; set; }
        public DateTime responseTime { get; set; }
        public List<Message> messages { get; set; }
    }

    public class MainAgency
    {
        public bool ownAgency { get; set; }
        public bool useOwnWebSettings { get; set; }
        public bool sendFlightInfoSms { get; set; }
        public int allowUnpaidRes { get; set; }
        public bool aceExport { get; set; }
        public bool allowNon3DPayments { get; set; }
        public bool bonusUseSysParam { get; set; }
        public bool bonusUserSeeAgencyW { get; set; }
        public bool bonusUserSeeOwnW { get; set; }
        public bool allowAddCredit { get; set; }
        public bool showAgencyLogoOnB2b { get; set; }
        public bool hideInstallmentTable { get; set; }
        public bool hideAgencyCreditOnWeb { get; set; }
        public bool force2FactorAuth { get; set; }
        public int location { get; set; }
    }

    public class Market
    {
        public string code { get; set; }
        public string name { get; set; }
        public string favicon { get; set; }
        public string faviconPng { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string code { get; set; }
        public int messageType { get; set; }
        public string message { get; set; }
    }

    public class Office
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Operator
    {
        public string code { get; set; }
        public string name { get; set; }
        public string thumbnail { get; set; }
        public bool agencyCanDiscountCommission { get; set; }
    }



    public class UserInfo
    {
        public MainAgency mainAgency { get; set; }
        public Agency agency { get; set; }
        public Office office { get; set; }
        public Operator @operator { get; set; }
        public Market market { get; set; }
        public int webSiteId { get; set; }
        public int marketWebSiteId { get; set; }
        public bool allowChangePassword { get; set; }
        public bool allowCreateNewUser { get; set; }
        public bool allowCreateAgency { get; set; }
        public bool allowMakeReservation { get; set; }
        public bool allowEditReservation { get; set; }
        public bool allowCancelReservation { get; set; }
        public bool allowB2BUpdate { get; set; }
        public string email { get; set; }
        public DateTime passwordChangedDate { get; set; }
        public bool allowApiAccess { get; set; }
        public DateTime lastAccessDate { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string code { get; set; }
    }
}