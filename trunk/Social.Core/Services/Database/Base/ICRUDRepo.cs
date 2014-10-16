using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Services.Database.Base
{
    interface ICRUDService<T>
    {
        //CREATE

        ///// <summary>
        ///// Creates a new model in the database
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //T Create(T model);

        ///// <summary>
        ///// Creates a list of models, returning the 
        ///// list of newly created models
        ///// </summary>
        ///// <param name="models"></param>
        ///// <returns></returns>
        //List<T> Create(List<T> models);
        
        ////READ
        ///// <summary>
        ///// Reads all 
        ///// </summary>
        ///// <returns></returns>
        //List<T> ReadAll();

        /// <summary>
        /// Reads All Deleted
        /// </summary>
        /// <returns></returns>
        List<T> ReadDeleted();


        ///// <summary>
        ///// Reads All 
        ///// </summary>
        ///// <returns></returns>
        //List<T> ReadAll();

        ///// <summary>
        ///// Reads By ID
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //T Read(Guid ID);

        ///// <summary>
        ///// Reads a model from the database by a model, using the modelID
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //T Read(T model);




        /// <summary>
        /// Reads all non deleted models, from the database, where the updated on date
        /// time field falls between the from and to dates specified, where by default
        /// it includes the dates specified. Time is converted into UTC for database
        /// purposes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isInclusive"></param>
        /// <returns></returns>
        List<T> ReadUpdatedOn(DateTime from, DateTime to, Boolean isInclusive = true);

        /// <summary>
        /// Reads all non deleted models, from the database, where the created on date
        /// time field falls between the from and to dates specified, where by default
        /// it includes the dates specified. Time is converted into UTC for database
        /// purposes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isInclusive"></param>
        /// <returns></returns>
        List<T> ReadCreatedOn(DateTime from, DateTime to, Boolean isInclusive = true);

        /// <summary>
        /// Reads all models, from the database, where the updated on date
        /// time field falls between the from and to dates specified, where by default
        /// it includes the dates specified. Time is converted into UTC for database
        /// purposes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isInclusive"></param>
        /// <returns></returns>
        List<T> ReadAllUpdatedOn(DateTime from, DateTime to, Boolean isInclusive = true);

        /// <summary>
        /// Reads all models, from the database, where the created on date
        /// time field falls between the from and to dates specified, where by default
        /// it includes the dates specified. Time is converted into UTC for database
        /// purposes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isInclusive"></param>
        /// <returns></returns>
        List<T> ReadAllCreatedOn(DateTime from, DateTime to, Boolean isInclusive = true);

        /// <summary>
        /// Reads all deleted models, from the database, where the created on date
        /// time field falls between the from and to dates specified, where by default
        /// it includes the dates specified. Time is converted into UTC for database
        /// purposes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isInclusive"></param>
        /// <returns></returns>
        List<T> ReadDeletedCreatedOn(DateTime from, DateTime to, Boolean isInclusive = true);

        /// <summary>
        /// Reads all deleted models, from the database, where the updated on date
        /// time field falls between the from and to dates specified, where by default
        /// it includes the dates specified. Time is converted into UTC for database
        /// purposes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isInclusive"></param>
        /// <returns></returns>
        List<T> ReadDeletedUpdatedOn(DateTime from, DateTime to, Boolean isInclusive = true);
        

        //UPDATE

        ///// <summary>
        ///// Updates a model, returning the updated model from the database
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //T Update(T model);

        ///// <summary>
        ///// Updates a list of models, returning the list of models from the database
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //List<T> Update(List<T> model);

        ///// <summary>
        ///// Creates or updates a model in the database, based on the models ID
        ///// If the model ID is a zeroed guid, then the model will be created, 
        ///// else the model will be updated, returning the model
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //T CreateOrUpdate(T model);

        ///// <summary>
        ///// Creates or updates a list model in the database, based on the models ID
        ///// If the model ID is a zeroed guid, then the model will be created, 
        ///// else the model will be updated, returning the list of models
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //List<T> CreateOrUpdate(List<T> model);
        

        //DELETE

        /// <summary>
        /// Soft deletes a model by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        T SoftDelete(Guid ID);

        /// <summary>
        /// Soft deletes a model by model, returning the model that has
        /// been deleted
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        T SoftDelete(T Model);

        /// <summary>
        /// Soft deletes a list of models, returning a list of models
        /// that have been deleted
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        List<T> SoftDelete(List<T> models);

        /// <summary>
        /// Soft deletes a list of guids, returning al list of models
        /// that have been deleted
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        List<T> SoftDelete(List<Guid> guids);



        /// <summary>
        /// Reverts the soft delete of a model by ID, comparing
        /// the model ID, returns the model
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        T UndoSoftDelete(Guid ID);

        /// <summary>
        /// Reverts the soft delete of a model by comparing the 
        /// model ID, returns the model
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        T UndoSoftDelete(T Model);

        /// <summary>
        /// Reverts the soft delete of the model by taking in a 
        /// list of models, and comparing a model ID, returning 
        /// a list of models
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        List<T> UndoSoftDelete(List<T> models);

        /// <summary>
        /// Reverts the soft delete of the model by taking in 
        /// a list of model ids, comparing the model ID's, returns
        /// a list of models
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        List<T> UndoSoftDelete(List<Guid> guids);




        /// <summary>
        /// Hard deletes a model by ID, returning the model that has been deleted
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        T HardDelete(Guid ID);
        
        /// <summary>
        /// Hard deletes a model, comparing the model ID 
        /// returning the model that has been deleted
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        T HardDelete(T Model);

        /// <summary>
        /// Hard deletes a list of models, comparing the model ID, 
        /// returning the list of models that have been deleted
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        List<T> HardDelete(List<T> models);

        /// <summary>
        /// Hard deletes a list of model IDS, comparing the model ID,
        /// returing a list of models that have been deleted
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        List<T>HardDelete(List<Guid> guids);




        //HELPERS
        

        Boolean Exists(T model);
        Boolean Exists(Guid ID);
        Boolean Exists(List<T> models);
        Boolean Exists(List<Guid> guids);

        
        //Manipulations
        T Duplicate(T model);
        T Duplicate(List<T> model);
        T CreateEmptyModel();
        List<T> CreateXEmptyModels(Int32 x);
        List<T> CreateXEmptyDeletedModels(Int32 x);
        

        //Time
        DateTime GetUpdatedOn(T model);
        DateTime GetUpdatedOn(Guid model);

        DateTime GetUpdatedOnUTC(T model);
        DateTime GetUpdatedOnUTC(Guid model);


        DateTime GetCreatedOn(T model);
        DateTime GetCreatedOn(Guid ID);

        DateTime GetCreatedOnUTC(T model);
        DateTime GetCreatedOnUTC(Guid ID);


        Boolean WasXCreatedBeforeY(T x, T y);
        Boolean WasXUpdatedBeforeY(T x, T y);
        Boolean WasEverUpdated(T model);

        T ResetUpdatedOn(Guid ID);
        T ResetUpdatedOn(T model);



    }
}
