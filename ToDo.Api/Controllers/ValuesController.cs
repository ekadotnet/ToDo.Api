using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        private class Example       //generalnie coś takiego nie powinno mieć miejsca w kontrolerze
        {                           //jest to tylko na potrzeby prezentacji (i żeby niepotrzebnie nie mieszać, w masterze tego nie będzie)
            public string Name => "Nazwa";
            public int Id { get; set; }
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)] //atrybut ProducesResponseType pozwala na pokazanie w dokumentacji jaki typ zostanie zwrócony z danym kodem statusu
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Example), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //drugi możliwy wariant użycia atrybutu ProducesResponseType z samym kodem statusu (przydatne, gdy np zwracamy NoContent, które z założenia nie posiada nic w ciele odpowiedzi)
        public IActionResult Get(int id) //typ IActionResult reprezentuje odpowiedzi z danym kodem statusu, można użyć gotowych metod np Ok() albo BadRequest() aby zwrócić dany obiekt z żądanym przez nas statusem
        {
            if (id == 0)    //jeśli id było 0, lub nie udało się sparsować wartości z query (np. api/values/qweqwe)
            {
                return BadRequest();    //zwracamy po prostu BadRequest (status 400) z pustym ciałem
            }

            var example = new Example {Id = id};

            return Ok(example); //zwracamy Ok (status 200) razem z przykładowym obiektem w ciele odpowiedzi
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
