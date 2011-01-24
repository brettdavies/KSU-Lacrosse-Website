using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KSULax.Entities;
using KSULax.Models;
using KSULax.Controllers;

namespace KSULax.Logic
{
    public class GameBL
    {
        KSULaxEntities _entities;

        public GameBL(KSULaxEntities entitity) { _entities = entitity; }

    }
}