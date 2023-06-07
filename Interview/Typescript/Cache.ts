import * as NodeCache from 'node-cache';

export const nodeCache = new NodeCache(); // instance of node-cache you should use for storing cached data

export function cache(ttl: number = 10) {
    return function (
        target: any,
        propertyName: string,
        propertyDescriptor: PropertyDescriptor,
    ) {
        const className = target.constructor.name; // class name taken from decorated method's class
        const originalMethod = propertyDescriptor.value; // under value is the original method itself

        propertyDescriptor.value = function (...args: any[]) {
            // only in the body of this function console.log will work for debugging since only this part is executed during the runtime
            // adjust the method to cache values before calling original one
            const cacheKey = className + JSON.stringify(args);
            if (nodeCache.has(cacheKey)) {
                //console.log('cache...');
                let item = nodeCache.get(cacheKey);

                if (item instanceof Error) {
                    throw item;
                }
                else {
                    return item;
                }
            }

            try {
                //console.log('real get...');
                const result = originalMethod.apply(this, args);

                if (result)
                    nodeCache.set(cacheKey, result, ttl);
                return result;
            }
            catch (e) {
                //console.log(e);
                nodeCache.set(cacheKey, e, ttl);
                throw e;
            }
        };

        // return decorated descriptor
        return propertyDescriptor;
    };
}
