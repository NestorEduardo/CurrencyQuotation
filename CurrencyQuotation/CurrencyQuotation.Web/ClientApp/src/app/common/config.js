"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Config = /** @class */ (function () {
    function Config() {
        this.countryCodes = [
            "DOP",
            "USD",
            "EUR",
            "AED"
        ];
    }
    Config.prototype.getCountryCodes = function () {
        return this.countryCodes;
    };
    return Config;
}());
exports.Config = Config;
//# sourceMappingURL=config.js.map