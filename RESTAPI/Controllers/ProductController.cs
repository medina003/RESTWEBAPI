using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Services;
namespace RESTAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public List<Product> GetAll()
    {
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(FileService.Reader("Products.json"));
        return products;
    }
    
    [HttpGet("id")]
    public Product GetById([FromHeader]int id)
    {
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(FileService.Reader("Products.json"));
        return products.Find(p => p.Id == id);
    }
    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(FileService.Reader("Products.json"));
        products!.Add(product);
        SerializeService.Serialize("Products.json",products,false);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Product product)
    {
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(FileService.Reader("Products.json"));
        var toPut = products.Find(p => p.Id == product.Id);
        var index = products.IndexOf(toPut);
        products[index] = product;  
        SerializeService.Serialize("Products.json",products,false);
        return Ok();
    }

    [HttpDelete("id")]
    public IActionResult Delete([FromHeader] int id)
    {
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(FileService.Reader("Products.json"));
        products.RemoveAll(p => p.Id == id);
        SerializeService.Serialize("Products.json",products,false);
        return Ok();
    }
}