using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        /*
         *we can use IEnumerable or list, the diference is in the view we don't use all the methods in List class (add, get by index, remove)
         * All we need is iterate over the membership types, so if we use IEnumerable  we get that functionality and in
         * the future we can replace with list or another collection and we cannot come back here and modify this proprty
         * because as long as the collection implement ienumerable, so our code is more loosely coupled
         */
        public Customer Customer { get; set; }
        /*
         * we can reuse a model store in our existing domain model  but sometimes in complex applications
         * the presentation of model on a view maybe can be diferent from how it's defined in the domain model of your application
         *in those situations if you want to reuse the existing entity you may up palluting that entity by adding
         * aditional properties witch are only required by a view, in that case you really need to separate that domain and
         * view model evolve indepently
         */
    }
}