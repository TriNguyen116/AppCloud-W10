using Ex08_ContosoPizza.Services.PizzaService;
using Ex08_ContosoPizza.Models.Pizza;
using Microsoft.AspNetCore.Mvc;

namespace Ex08_ContosoPizza.Controllers;
[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
  public PizzaController()
  {
  }
  // GET all action
  [HttpGet]
  public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
  // GET by Id action
  [HttpGet("{id}")]
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);
    if (pizza == null)
      return NotFound();
    return pizza;
  }
  // POST action
  [HttpPost]
  public ActionResult<Pizza> Create(Pizza pizza)
  {
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
  }

  // PUT action
  [HttpPut("{id}")]
  public IActionResult Update(int id, Pizza pizza)
  {
    if (id != pizza.Id)
      return BadRequest();

    var existingPizza = PizzaService.Get(id);
    if (existingPizza == null)
      return NotFound();

    PizzaService.Update(pizza);
    return NoContent();
  }

  // DELETE action
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var existingPizza = PizzaService.Get(id);
    if (existingPizza == null)
      return NotFound();

    PizzaService.Delete(id);
    return NoContent();
  }
}