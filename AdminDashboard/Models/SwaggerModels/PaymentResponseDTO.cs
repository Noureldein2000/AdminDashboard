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
    /// PaymentResponseDTO
    /// </summary>
    [DataContract]
        public partial class PaymentResponseDTO :  IEquatable<PaymentResponseDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentResponseDTO" /> class.
        /// </summary>
        /// <param name="code">code.</param>
        /// <param name="message">message.</param>
        /// <param name="availableBalance">availableBalance.</param>
        /// <param name="transactionId">transactionId.</param>
        /// <param name="invoiceId">invoiceId.</param>
        /// <param name="localDate">localDate.</param>
        /// <param name="serverDate">serverDate.</param>
        /// <param name="dataList">dataList.</param>
        /// <param name="receipt">receipt.</param>
        public PaymentResponseDTO(int? code = default(int?), string message = default(string), double? availableBalance = default(double?), int? transactionId = default(int?), int? invoiceId = default(int?), string localDate = default(string), string serverDate = default(string), List<DataListDTO> dataList = default(List<DataListDTO>), List<Root> receipt = default(List<Root>))
        {
            this.Code = code;
            this.Message = message;
            this.AvailableBalance = availableBalance;
            this.TransactionId = transactionId;
            this.InvoiceId = invoiceId;
            this.LocalDate = localDate;
            this.ServerDate = serverDate;
            this.DataList = dataList;
            this.Receipt = receipt;
        }
        
        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public int? Code { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets AvailableBalance
        /// </summary>
        [DataMember(Name="availableBalance", EmitDefaultValue=false)]
        public double? AvailableBalance { get; set; }

        /// <summary>
        /// Gets or Sets TransactionId
        /// </summary>
        [DataMember(Name="transactionId", EmitDefaultValue=false)]
        public int? TransactionId { get; set; }

        /// <summary>
        /// Gets or Sets InvoiceId
        /// </summary>
        [DataMember(Name="invoiceId", EmitDefaultValue=false)]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// Gets or Sets LocalDate
        /// </summary>
        [DataMember(Name="localDate", EmitDefaultValue=false)]
        public string LocalDate { get; set; }

        /// <summary>
        /// Gets or Sets ServerDate
        /// </summary>
        [DataMember(Name="serverDate", EmitDefaultValue=false)]
        public string ServerDate { get; set; }

        /// <summary>
        /// Gets or Sets DataList
        /// </summary>
        [DataMember(Name="dataList", EmitDefaultValue=false)]
        public List<DataListDTO> DataList { get; set; }

        /// <summary>
        /// Gets or Sets Receipt
        /// </summary>
        [DataMember(Name="receipt", EmitDefaultValue=false)]
        public List<Root> Receipt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PaymentResponseDTO {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  AvailableBalance: ").Append(AvailableBalance).Append("\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  LocalDate: ").Append(LocalDate).Append("\n");
            sb.Append("  ServerDate: ").Append(ServerDate).Append("\n");
            sb.Append("  DataList: ").Append(DataList).Append("\n");
            sb.Append("  Receipt: ").Append(Receipt).Append("\n");
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
            return this.Equals(input as PaymentResponseDTO);
        }

        /// <summary>
        /// Returns true if PaymentResponseDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of PaymentResponseDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymentResponseDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.AvailableBalance == input.AvailableBalance ||
                    (this.AvailableBalance != null &&
                    this.AvailableBalance.Equals(input.AvailableBalance))
                ) && 
                (
                    this.TransactionId == input.TransactionId ||
                    (this.TransactionId != null &&
                    this.TransactionId.Equals(input.TransactionId))
                ) && 
                (
                    this.InvoiceId == input.InvoiceId ||
                    (this.InvoiceId != null &&
                    this.InvoiceId.Equals(input.InvoiceId))
                ) && 
                (
                    this.LocalDate == input.LocalDate ||
                    (this.LocalDate != null &&
                    this.LocalDate.Equals(input.LocalDate))
                ) && 
                (
                    this.ServerDate == input.ServerDate ||
                    (this.ServerDate != null &&
                    this.ServerDate.Equals(input.ServerDate))
                ) && 
                (
                    this.DataList == input.DataList ||
                    this.DataList != null &&
                    input.DataList != null &&
                    this.DataList.SequenceEqual(input.DataList)
                ) && 
                (
                    this.Receipt == input.Receipt ||
                    this.Receipt != null &&
                    input.Receipt != null &&
                    this.Receipt.SequenceEqual(input.Receipt)
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
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.AvailableBalance != null)
                    hashCode = hashCode * 59 + this.AvailableBalance.GetHashCode();
                if (this.TransactionId != null)
                    hashCode = hashCode * 59 + this.TransactionId.GetHashCode();
                if (this.InvoiceId != null)
                    hashCode = hashCode * 59 + this.InvoiceId.GetHashCode();
                if (this.LocalDate != null)
                    hashCode = hashCode * 59 + this.LocalDate.GetHashCode();
                if (this.ServerDate != null)
                    hashCode = hashCode * 59 + this.ServerDate.GetHashCode();
                if (this.DataList != null)
                    hashCode = hashCode * 59 + this.DataList.GetHashCode();
                if (this.Receipt != null)
                    hashCode = hashCode * 59 + this.Receipt.GetHashCode();
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
