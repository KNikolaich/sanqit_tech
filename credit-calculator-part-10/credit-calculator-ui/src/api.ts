import { CalcType, CalculationParameters, CalculationResult } from "./models";

class Api {
    private _baseAddress: string;

    constructor(baseAddress: string) {
        this._baseAddress = baseAddress;
    }

    calculateAsyc = async (calculationParameters: CalculationParameters, calcType: CalcType) => {
        return await this.postAsync<CalculationParameters, CalculationResult>(`/credit-calculator/${calcType}/calculate`, calculationParameters);
    }

    private postAsync = async<TModel, TResponse>(route: string, model: TModel) => {
        const response = await fetch(`${this._baseAddress}${route}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(model)
        })

        return await response.json() as TResponse;
    }
}

export default Api;