using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
namespace ERestaurant.Models
{
    [MetadataType(typeof(SessionStructureMetadata))]
    public partial class SessionStructure
    {
        
        public class SessionStructureMetadata
        {
            public long SessionID { get; set; }

            public long SessionBelongTo { get; set; }
        }
    }
    public class SessionStructureItem
    {
        public long sessionId;
        public long sessionBelongTo;

        public SessionStructureItem(long sessionId, long sessionBelongTo)
        {
            this.sessionId = sessionId;
            this.sessionBelongTo = sessionBelongTo;
        }
        public long SessionID 
        {
            get { return sessionId; }
            set { sessionId = value; }
        }

        public long SessionBelongTo
        {
            get { return sessionBelongTo; }
            set { sessionBelongTo = value; }
        }
    }
}