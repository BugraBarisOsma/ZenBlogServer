using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ZenBlog.Application.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }
        public IEnumerable<Error>? Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Errors == null || !Errors.Any();
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;

        public static BaseResult<T> Success(T data)
        {
            return new BaseResult<T> { Data = data };
        }

        public static BaseResult<T> Failure(string error)
        {
            return new BaseResult<T> { Errors = [new Error { ErrorMessage = error}] };
        }
        public static BaseResult<T> Failure()
        {
            return new BaseResult<T> { Errors = [new Error { ErrorMessage = "Unexpected failure occured" }] };
        }
        public static BaseResult<T> Failure(IEnumerable<IdentityError> errors)
        {
            return new BaseResult<T> { Errors = (from error in errors select new Error { PropertyMessage = error.Code,ErrorMessage=error.Description}) };
        }
        public static BaseResult<T> Failure(IEnumerable<string> errors)
        {
            return new BaseResult<T> { Errors = (from error in errors select new Error { ErrorMessage = error}) };
        }
        public static BaseResult<T> NotFound(string error)
        {
            return new BaseResult<T> { Errors = [new Error { ErrorMessage=error}] };
        }   
    }
}