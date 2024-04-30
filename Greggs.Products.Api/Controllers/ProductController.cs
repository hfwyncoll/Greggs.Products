using System;
using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IDataAccess<Product> _productAccess;

    public ProductController(ILogger<ProductController> logger, IDataAccess<Product> productAccess)
    {
        _logger = logger;
        _productAccess = productAccess;
    }

    [HttpGet("GBP")]
    public IEnumerable<Product> GetGbp(int pageStart = 0, int? pageSize = null)
    {
        // If user does not state a pageSize, return all products
        pageSize ??= _productAccess.Size();

        return _productAccess.List(pageStart,pageSize).ToArray();
        
    } 
    
    [HttpGet("EUR")]
    public IEnumerable<Product> GetEur(int pageStart = 0, int? pageSize = null)
    {
        // If user does not state a pageSize, return all products
        pageSize ??= _productAccess.Size();

        IEnumerable<Product> productList = _productAccess.List(pageStart, pageSize);

        foreach (Product product in productList)
        {
            product.PriceInEur = Math.Round(product.PriceInPounds * ExchangeRate.GbpToEurExchangeRate,2,MidpointRounding.AwayFromZero);
        }

        return productList.ToArray();

    }
    
}