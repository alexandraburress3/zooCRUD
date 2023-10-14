using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using zooCRUD.Models;
using zooCRUD.Interfaces;

namespace zooCRUD.Controllers;

[ApiController]
public class ZooController : Controller
{
    private readonly ILogger<ZooController> _logger;
    private readonly IZooRepository _zooRepository;

    public ZooController(ILogger<ZooController> logger, IZooRepository repository)
    {
        _logger = logger;
        _zooRepository = repository;
    }

    [HttpPost]
    [Route("/post")]
    public IActionResult Post(string name, Species species, int height, int weight)
    {
        var result = _zooRepository.PostAnimal(name, species, height, weight);
 
        return new OkObjectResult(result);
    }

    [HttpGet]
    [Route("/get")]
    public IActionResult Get(string name, Species species)
    {
        var result = _zooRepository.GetAnimal(name, species);
 
        return new OkObjectResult(result);
    }

    [HttpPut]
    [Route("/update")]
    public IActionResult Update(string name, Species species, int height, int weight)
    {
        var result = _zooRepository.UpdateAnimal(name, species, height, weight);
 
        return new OkObjectResult(result);
    }

    [HttpDelete]
    [Route("/delete")]
    public IActionResult Delete(string name, Species species)
    {
        var result = _zooRepository.DeleteAnimal(name, species);
 
        return new OkObjectResult(result);
    }

    [HttpGet]
    [Route("/getAll")]
    public IActionResult GetAllAnimals()
    {
        var result = _zooRepository.GetAllAnimals();
 
        return new OkObjectResult(result);
    }

}
