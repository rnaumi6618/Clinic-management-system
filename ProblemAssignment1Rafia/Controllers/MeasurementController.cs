/* ProblemAssignment1Rafia.cs
 * BP Measurement Webpage
 * Revision History: 01.10.23-10.10.23
 * Rafia Naumi
 * 10.09.23*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProblemAssignment1Rafia.Entities;
using ProblemAssignment1Rafia.Models;

namespace ProblemAssignment1Rafia.Controllers
{
    public class MeasurementController : Controller
    {
        /// <summary>
        /// The DI container hands us this DB context object when the controller
        /// is created to handle an HTTP request
        /// </summary>
        public MeasurementController(BPMeasurementsDbContext bPMeasurementsDb) 
        {
            // we store it in a private data field so that we can use it later:
            _bPMeasurementsDb = bPMeasurementsDb;
        }
        public IActionResult List()
        {
            //use our Db Context here to query for measurements but Include the position Object:
            //When query measurement , it is a must to include full associated position as well

            List <BPMeasurement> measurementList = _bPMeasurementsDb.BPMeasurements.Include(m => m.Position).ToList();

            return View(measurementList);
        }
        //A Get handler that return a form to add a new measurement
        [HttpGet()]
        public IActionResult Add()
        {
            // Create and populate a view model...
            var positions = _bPMeasurementsDb.Positions.OrderBy(p => p.PositionName).ToList();

            UpdateMeasurementViewModel updateViewModel = new UpdateMeasurementViewModel()  
            {
                BPMeasurement = new BPMeasurement(),
                Positions = positions
            };

            // and then pass it to the view:
            return View(updateViewModel);

        }
        //The post handler that add a measurement data in the http post body,
        //pass as a param, is then added to the data base.

        [HttpPost()]
        public IActionResult Add(UpdateMeasurementViewModel updateMeasurementViewModel)
        {
            if (ModelState.IsValid)
            {
                //because it is valid,add it to the DB and save changes
                _bPMeasurementsDb.BPMeasurements.Add(updateMeasurementViewModel.BPMeasurement);
                _bPMeasurementsDb.SaveChanges();

                // Set a success message
                TempData["Message"] = "New Measurement added successfully";

                //we redirect back to the all measurement views
                return RedirectToAction("List", "Measurement");
            }
            else
            { // re-populate the view model with the list of genres...
                var Positions = _bPMeasurementsDb.Positions.OrderBy(p => p.PositionName).ToList();

                updateMeasurementViewModel.Positions = Positions;

                // and then pass it to the view:
                return View(updateMeasurementViewModel);
            }
        }
        //A Get handler that return the form filled with the measurement's
        //with id passed as parameter current values
        [HttpGet()]
        public IActionResult Edit(int id)
        {
            //need to pass id as a param to query DB for that measurement
            var measurment = _bPMeasurementsDb.BPMeasurements.Find(id);

            // Create and populate a view model...
            var positions = _bPMeasurementsDb.Positions.OrderBy(p => p.PositionName).ToList();

            UpdateMeasurementViewModel updateViewModel = new UpdateMeasurementViewModel()
            {
                BPMeasurement = measurment,
                Positions = positions
            };

            // and then pass it to the view:
            return View(updateViewModel);


        }
        //The post handler that edit a measurement using the data in the http post body,
        //pass as a param, is then added to the data base.
        [HttpPost()]
        public IActionResult Edit(UpdateMeasurementViewModel updateMeasurementViewModel)
        {
            if (ModelState.IsValid)
            {
                //because it is valid,update it to the DB and save changes
                _bPMeasurementsDb.BPMeasurements.Update(updateMeasurementViewModel.BPMeasurement);
                _bPMeasurementsDb.SaveChanges();

                // Set a success message
                TempData["Message"] = "Measurement Updated successfully";

                //we redirect back to the all measurement views
                return RedirectToAction("List", "Measurement");
            }
            else
            { 
                // re-populate the view model with the list of genres...
                var Positions = _bPMeasurementsDb.Positions.OrderBy(p => p.PositionName).ToList();

                updateMeasurementViewModel.Positions = Positions;

                // and then pass it to the view:
                return View(updateMeasurementViewModel);
            }
        }//A Get handler that return the form filled with the measurement's
        //with id passed as parameter current values
        [HttpGet()]
        public IActionResult Delete(int id)
        {
            //need to pass id as a param to query DB for that measurement
            var measurment = _bPMeasurementsDb.BPMeasurements.Find(id);
            return View(measurment);

        }
        //The post handler that Delete a measurement using the data in the http post body,
        //pass as a param, is then added to the data base.
        [HttpPost()]
        public IActionResult Delete(BPMeasurement measurement)
        {
            //Delete it to the DB and save changes
            _bPMeasurementsDb.BPMeasurements.Remove(measurement);
            _bPMeasurementsDb.SaveChanges();

            // Set a success message
            TempData["Message"] = "Measurement Deleted successfully";

            //we redirect back to the all measurement views
            return RedirectToAction("List", "Measurement");
        }


        private BPMeasurementsDbContext _bPMeasurementsDb;
    }
}