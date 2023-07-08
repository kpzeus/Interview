def count_subarray_with_mean(arr, s):
    count = 0  # Variable to store the count of subarrays
    prefix_sum = 0  # Prefix sum of the array elements
    prefix_sum_count = {0: 1}  # Dictionary to store prefix sum occurrences

    # Iterate over each element in the array
    for num in arr:
        prefix_sum += num  # Update the prefix sum
        
        if num == s:
            count=count+1

        # Calculate the difference between current prefix sum and the target mean multiplied by the subarray length
        diff = prefix_sum - s * len(prefix_sum_count)

        # If the difference exists in the prefix sum occurrences, add its count to the total count
        if diff in prefix_sum_count:
            count += prefix_sum_count[diff]

        # Increment the count of current prefix sum occurrence or initialize it to 1
        prefix_sum_count[prefix_sum] = prefix_sum_count.get(prefix_sum, 0) + 1

    return count


# Example usage
arr = [1,2,3]
target_mean = 2

result = count_subarray_with_mean(arr, target_mean)
print("Count of subarrays with mean equal to", target_mean, ":", result)