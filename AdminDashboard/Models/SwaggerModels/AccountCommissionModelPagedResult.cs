/* 
 * API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = AdminDashboard.SwaggerClientHelpers.SwaggerDateConverter;

namespace AdminDashboard.Models.SwaggerModels
{
    /// <summary>
    /// AccountCommissionModelPagedResult
    /// </summary>
    [DataContract]
        public partial class AccountCommissionModelPagedResult :  IEquatable<AccountCommissionModelPagedResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCommissionModelPagedResult" /> class.
        /// </summary>
        /// <param name="currentPage">currentPage.</param>
        /// <param name="pageCount">pageCount.</param>
        /// <param name="pageSize">pageSize.</param>
        /// <param name="results">results.</param>
        public AccountCommissionModelPagedResult(int? currentPage = default(int?), int? pageCount = default(int?), int? pageSize = default(int?), List<AccountCommissionModel> results = default(List<AccountCommissionModel>))
        {
            this.CurrentPage = currentPage;
            this.PageCount = pageCount;
            this.PageSize = pageSize;
            this.Results = results;
        }
        
        /// <summary>
        /// Gets or Sets CurrentPage
        /// </summary>
        [DataMember(Name="currentPage", EmitDefaultValue=false)]
        public int? CurrentPage { get; set; }

        /// <summary>
        /// Gets or Sets PageCount
        /// </summary>
        [DataMember(Name="pageCount", EmitDefaultValue=false)]
        public int? PageCount { get; set; }

        /// <summary>
        /// Gets or Sets PageSize
        /// </summary>
        [DataMember(Name="pageSize", EmitDefaultValue=false)]
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or Sets FirstRowOnPage
        /// </summary>
        [DataMember(Name="firstRowOnPage", EmitDefaultValue=false)]
        public int? FirstRowOnPage { get; private set; }

        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name="results", EmitDefaultValue=false)]
        public List<AccountCommissionModel> Results { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountCommissionModelPagedResult {\n");
            sb.Append("  CurrentPage: ").Append(CurrentPage).Append("\n");
            sb.Append("  PageCount: ").Append(PageCount).Append("\n");
            sb.Append("  PageSize: ").Append(PageSize).Append("\n");
            sb.Append("  FirstRowOnPage: ").Append(FirstRowOnPage).Append("\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as AccountCommissionModelPagedResult);
        }

        /// <summary>
        /// Returns true if AccountCommissionModelPagedResult instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountCommissionModelPagedResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountCommissionModelPagedResult input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CurrentPage == input.CurrentPage ||
                    (this.CurrentPage != null &&
                    this.CurrentPage.Equals(input.CurrentPage))
                ) && 
                (
                    this.PageCount == input.PageCount ||
                    (this.PageCount != null &&
                    this.PageCount.Equals(input.PageCount))
                ) && 
                (
                    this.PageSize == input.PageSize ||
                    (this.PageSize != null &&
                    this.PageSize.Equals(input.PageSize))
                ) && 
                (
                    this.FirstRowOnPage == input.FirstRowOnPage ||
                    (this.FirstRowOnPage != null &&
                    this.FirstRowOnPage.Equals(input.FirstRowOnPage))
                ) && 
                (
                    this.Results == input.Results ||
                    this.Results != null &&
                    input.Results != null &&
                    this.Results.SequenceEqual(input.Results)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.CurrentPage != null)
                    hashCode = hashCode * 59 + this.CurrentPage.GetHashCode();
                if (this.PageCount != null)
                    hashCode = hashCode * 59 + this.PageCount.GetHashCode();
                if (this.PageSize != null)
                    hashCode = hashCode * 59 + this.PageSize.GetHashCode();
                if (this.FirstRowOnPage != null)
                    hashCode = hashCode * 59 + this.FirstRowOnPage.GetHashCode();
                if (this.Results != null)
                    hashCode = hashCode * 59 + this.Results.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
