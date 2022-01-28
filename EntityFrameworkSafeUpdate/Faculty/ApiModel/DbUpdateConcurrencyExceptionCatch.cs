using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiResult
{
    /// <summary>
    /// DB업데이트시 속성이 ConcurrencyCheck오류를 처리하는 클래스
    /// </summary>
    /// <typeparam name="T">처리할 모델 형식</typeparam>
    public class DbUpdateConcurrencyExceptionCatch<T> where T : class
    {

        /// <summary>
        /// DbUpdateConcurrencyException를 전달 받아 다시 저장을 시도한다.
        /// </summary>
        /// <param name="e"></param>
        public void ProcSave(
            DbUpdateConcurrencyException e)
        {
            foreach (var entry in e.Entries)
            {
                //if (true == Object.Equals(entry.Entity, T))
                if (entry.Entity is T)
                {
                    var proposedValues = entry.CurrentValues;
                    var databaseValues = entry.GetDatabaseValues();

                    foreach (var property in proposedValues.Properties)
                    {
                        var proposedValue = proposedValues[property];
                        var databaseValue = databaseValues[property];

                        // TODO: decide which value should be written to database
                        // proposedValues[property] = <value to be saved>;
                    }

                    // Refresh original values to bypass next concurrency check
                    entry.OriginalValues.SetValues(databaseValues);
                }
                else
                {
                    throw new NotSupportedException(
                        "Don't know how to handle concurrency conflicts for "
                        + entry.Metadata.Name);
                }
            }//foreach (var entry in e.Entries)
        }
    }
}
