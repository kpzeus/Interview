function typeCheck(object) {
    Object.keys(object).forEach(key => {
        const value = object[key];
        validate(key, value, true);
    });

    return new Proxy(object, {
        set(target, key, value) {
            validate(key, value, false);
            target[key] = value;
            return true;
        }
    });
}

function validate(key, value, defaultCheck) {
    const keyParts = key.split('_');

    if (keyParts.length > 1) {
        let propType = keyParts[1];
        const valueType = typeof value;

        if (propType == 'bool') {
            propType = 'boolean';
        }

        console.log(key + " " + value + " " + propType + " " + valueType);

        switch (propType) {
            case 'int':
            case 'number':
            case 'float':
            case 'string':
            case 'boolean':
                if (
                    propType !== valueType &&
                    !(valueType == 'number' && propType == 'int' && value == parseInt(value, 10)) &&
                    !(valueType == 'number' && propType == 'float' && value != parseInt(value, 10))
                ) {
                    throw new Error(`Invalid type. Expected ${propType}, but received ${valueType}.`);
                }

                if (defaultCheck) {
                    let defaultValue = null;

                    switch (valueType) {
                        case 'number':
                            defaultValue = 0;
                            break;
                        case 'boolean':
                            defaultValue = false;
                            break;
                        case 'float':
                            defaultValue = 0;
                            break;
                    }

                    // if (value != defaultValue) {
                    //   throw new Error(`Invalid value. Expected ${defaultValue}, but received ${value}.`);
                    // }
                }
        }
    }
}

module.exports = typeCheck;
