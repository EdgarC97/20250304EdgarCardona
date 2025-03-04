namespace StudentManagementApi.Models
{
    /// <summary>
    /// Generic API response wrapper.
    /// </summary>
    /// <typeparam name="T">Type of the data payload.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indicates if the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// A message describing the result.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The payload data.
        /// </summary>
        public T Data { get; set; } = default!;
    }
}
