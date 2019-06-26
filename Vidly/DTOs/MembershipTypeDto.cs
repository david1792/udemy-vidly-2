using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        /**
         * theres no need to add all membershiptype here because if the clien wants to now
         * the details about a given membership type type they can use the id here to send to potencial a new endpoint
         *for membershiotypes, so well keep this lightweight
         */
    }
}