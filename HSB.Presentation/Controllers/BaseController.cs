﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSB.Presentation.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public abstract class BaseController : ControllerBase
	{
	}
}
