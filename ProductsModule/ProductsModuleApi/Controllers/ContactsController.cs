﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductModuleDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsModuleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contacts;

        public ContactsController(IContactsService contacts)
        {
            _contacts = contacts;
        }

        [HttpGet("allcontacts")]
        public IActionResult GetAllContacts()
        {
            var allContacts = _contacts.GetAllContacts();

            return Ok(allContacts);
        }
    }
}
