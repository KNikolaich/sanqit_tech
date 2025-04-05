import "./styles.css";

import Api from "./api";
import { CalcType, CalculationParameters } from "./models";
import { printCalculationResult } from "./utils/print-helpers";
import { createElement, render } from "./utils/render";

//const api = new Api("https://localhost:7081");
const api = new Api("https://api-credit-calculator.sanqit.ru");

const app = document.querySelector("#app")!;

const parametersContainer = createElement<HTMLDivElement>(`<div class="parameters-container"></div>`);
const resultContainer = createElement<HTMLDivElement>(`<div class="results-container"></div>`);

const creditInputElement = createElement<HTMLInputElement>(`<input placeholder="credit" value="200000" />`);
const reateInputElement = createElement<HTMLInputElement>(`<input placeholder="rate" value="20" />`);
const periodInputElement = createElement<HTMLInputElement>(`<input placeholder="period" value="12" />`);
const calcTypeElement = createElement<HTMLSelectElement>(`
<select>
    <option>annuity</option>
    <option>differentiated</option>
</select>
`);

render(creditInputElement, parametersContainer);
render(reateInputElement, parametersContainer);
render(periodInputElement, parametersContainer);
render(calcTypeElement, parametersContainer);

const calculateButtonElement = createElement<HTMLButtonElement>(`<button>Calculate</button>`);
calculateButtonElement.addEventListener("click", async () => {
    const calculationParameters : CalculationParameters = {
        credit: parseFloat(creditInputElement.value),
        rate: parseFloat(reateInputElement.value),
        period: parseInt(periodInputElement.value)
    };

    const calcType = calcTypeElement.value as CalcType;
    const calculationResult = await api.calculateAsyc(calculationParameters, calcType);

    printCalculationResult(calculationResult, resultContainer);
});

render(calculateButtonElement, parametersContainer);

render(parametersContainer, app);
render(resultContainer, app);