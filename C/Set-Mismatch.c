#include <stdlib.h>

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* findErrorNums(int* nums, int numsSize, int* returnSize) {
    int* result = (int*)malloc(2 * sizeof(int));
    if (!result) {
        *returnSize = 0;
        return NULL;
    }

    for (int i = 0; i < numsSize; ++i) {
        if (nums[abs(nums[i]) - 1] < 0) {
            result[0] = abs(nums[i]);
        } else {
            nums[abs(nums[i]) - 1] *= -1;
        }
    }

    for (int i = 0; i < numsSize; ++i) {
        if (nums[i] > 0) {
            result[1] = i + 1;
        } else {
            nums[i] *= -1;
        }
    }

    *returnSize = 2;
    return result;
}

