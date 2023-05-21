import React from "react";
import { useState, useEffect } from "react";
import axios from 'axios';

// GET List of continents

// GET List of countries {For a given continent and number fetched is limited}

// GET Details of the selected country
const CountryView = () => {
  const [continentCode, setContinentCode] = useState('');
  const [continentOptions, setContinentOptions] = useState([]);
  const [numberOfCountries, setNumberOfCountries] = useState(2);
  const [selectedCountry, setSelectedCountry] = useState([]);


  useEffect(() => {
    const fetchContinentData = async () => {
      try {
        const response = await axios.get('http://localhost:5000/WorldMap/GetAllContinents');
        const continents = response.data.continents;

        const options = continents.map((continent) => ({
          code: continent.code,
          name: continent.name
        }));

        console.log(options)

        setContinentOptions(options);
      } catch (error) {
        console.error('Error fetching continent data:', error);
      }
    };

    fetchContinentData();
  }, []);

  const handleNumCountriesChange = (event) => {
    const num = Number(event.target.value);
    setNumberOfCountries(num);
  };

  const handleContinentChange = (event) => {
    const code = event.target.value;
    setContinentCode(code);


  };

  const handleContinentSubmit = async (event) => {
    event.preventDefault();

    if (numberOfCountries < 2 || numberOfCountries > 10) {
      alert('Please enter a number between 2 and 10');
      return;
    }

    try {
      const response = await axios.get(`http://localhost:5000/WorldMap/GetCountriesFrom/${continentCode}/${numberOfCountries}`);
      const countries = response.data.countries;

      const retreivedCountries = countries.map((country) => ({
        code: country.code,
        name: country.name,
        currency: country.currency,
        phone: country.phone,
        languages: country.languages,
        continent: country.continent
      }));

      console.log(retreivedCountries)

      setSelectedCountry(retreivedCountries);
    } catch (error) {
      console.error('Error fetching continent data:', error);
    }
  }
    

    return (
        <div>
        <div class="col-lg-12 shadow">
            <div class="card card-lg-12 mt-2 border border-dark">
            <h5 class="card-title p-2">Choose a desired continent code:</h5>
              <div class="card-body">
              <form class="form-inline" onSubmit={handleContinentSubmit}>
                  <div class="form-group mx-sm-5">
                  <select value={continentCode} onChange={handleContinentChange}>
                      <option value="" selected>Select Continent Code</option>
                      {continentOptions.map((continent) => (
                      <option key={continent.code} value={continent.code}>
                          {continent.name}
                      </option>
                      ))}
                  </select>
                  </div>
                  <div class="form-group mx-sm-2 float-right">
                    <label>Number of countries:</label>
                    <input type="text" value={numberOfCountries} onChange={handleNumCountriesChange} class="form-control ml-2" placeholder="from 2 to 10" required/>
                  </div>
                  <div class="form-group mx-sm-2 float-right">
                    <button type="submit" class="btn btn-primary">Submit</button>
                  </div>
              </form> 
              </div>             
              <div className="container">
              <div className="row">
              {selectedCountry==null ? <p>Awaiting results... Please wait...</p> : selectedCountry.map((country) => (
              <div key={country.code} className="col-md-4">
                <div className="card mb-3">
                  <div className="card-body">
                    <h5 className="card-title">
                      {country.name ? country.name : <p class="text-danger">'No information found!'</p>}
                    </h5>
                    <p className="card-text">
                      Currency: {country.currency ? country.currency : <p class="text-danger">'No information found!'</p>}
                    </p>
                    <p className="card-text">
                      Phone: {country.phone ? country.phone : <p class="text-danger">'No information found!'</p>}
                    </p>
                    <p className="card-text">Languages:</p>
                    <ul className="list-group">
                      {country.languages.length > 0 ? (
                        country.languages.map((language, index) => (
                          <li key={index} className="list-group-item">
                            {language.name ? language.name : <p class="text-danger">'No information found!'</p>}
                          </li>
                        ))
                      ) : (
                        <li className="list-group-item"><p class="text-danger">No information found!</p></li>
                      )}
                    </ul>
                  </div>
                  <div className="card-footer">
                    <small className="text-muted">
                      Continent: {country.continent.name ? country.continent.name : <p class="text-danger">'No information found!'</p>}
                    </small>
                  </div>
                </div>
              </div>
            ))}
            </div>
            </div>
            </div>
            </div>
        </div>
    )
}

export default CountryView