﻿using TravelEstates.Business.Models.Enums;

namespace TravelEstates.Business.Models.Results.Base
{
    /// <summary>
    /// Represents a generic result with status code, error messages, and optional data.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the result.</typeparam>
    public interface IResult<T>
    {
        /// <summary>
        /// Gets the HTTP status code associated with the result.
        /// </summary>
        TravelEstatesStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the collection of error messages associated with the result.
        /// </summary>
        IEnumerable<string> ErrorMessages { get; }

        /// <summary>
        /// Gets the data contained in the result, if applicable.
        /// </summary>
        T Data { get; }
    }
}
