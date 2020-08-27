using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpTraining
{
    public interface Endpoints
    {

        protected const string API_KEY = "$2a$10$acz0eQe5a76QO5wgZZ.piuUZZ.chuB2wObXDm7WIQjpkCBMJc6niK";

        protected const string BASE_URL = "https://www.potterapi.com/v1/";

        protected const string GET_SORTING_HAT = "/sortingHat";

        protected const string GET_CHARACTERS = "/characters";

        protected const string GET_ONE_CHARACTER = "/characters/";

        protected const string GET_HOUSES = "houses";

        protected const string GET_ONE_HOUSE = "/houses/";

        protected const string GET_SPELLS = "/spells";

        protected const string HANNAH_ID = "5a0fa4daae5bc100213c232e";


    }
}
