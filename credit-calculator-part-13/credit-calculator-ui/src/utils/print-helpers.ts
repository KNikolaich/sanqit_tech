import { CalculationResult, PaymentInfo } from "../models";
import { createElement, render } from "./render";

const printCalculationResult = (calculationResult: CalculationResult, container: Element) => {
    const {
        payment,
        sumPayment,
        sumMainDebtPayment,
        sumPercentPayment,
        mainDebtInPercent,
        percentsInPercent,
        paymentInfos
    } = calculationResult;

    container.innerHTML = '';
    const commonInfoElement = createElement<HTMLTableElement>(`
<table>
  <tr>
    <td>Ежемесячный платёж</td>
    <td>${payment}</td>
  </tr>
  <tr>
    <td>Начисленные проценты</td>
    <td>${sumPercentPayment}</td>
  </tr>
  <tr>
    <td>Долг + проценты</td>
    <td>${sumPayment}</td>
  </tr>
  <tr>
    <td>От общец уплаченной суммы</td>
    <td>Основной долг=${mainDebtInPercent}%;Проценты=${percentsInPercent}%</td>
  </tr>
</table>
`);
    render(commonInfoElement, container);

    const paymentInfosElement = createElement<HTMLTableElement>(`
<table>
  <tr>
    <th>№</th>
    <th>Сумма платежа</th>
    <th>Платёж по основному долгу</th>
    <th>Платёж по процентам</th>
    <th>Остаток долга</th>
  </tr>
  ${paymentInfos.map((paymentInfo) => {
        return `<tr>
  <td>${paymentInfo.paymentNumber}</td>
  <td>${paymentInfo.payment}</td>
  <td>${paymentInfo.mainDebtPayment}</td>
  <td>${paymentInfo.percentPayment}</td>
  <td>${paymentInfo.debt}</td>
</tr>`
    }).join('')}
</table>`);

    render(paymentInfosElement, container);

    const totalInfoElement = createElement<HTMLTableElement>(`
<table>
  <tr>
    <td>Выплачено всего</td>
    <td>${sumPayment}</td>
  </tr>
  <tr>
    <td>Сумма выплаченного долга</td>
    <td>${sumMainDebtPayment}</td>
  </tr>
  <tr>
    <td>Сумма выплаченных процентов</td>
    <td>${sumPercentPayment}</td>
  </tr>
</table>
`);

    render(totalInfoElement, container);

    const diagramElement = createDiagramElement(paymentInfos);
    render(diagramElement, container);
}

const createDiagramElement = (paymentInfos: PaymentInfo[]) => {
    return createElement<HTMLDivElement>(`
<div class="diagram">${paymentInfos.map((paymentInfo) => {
    const left = paymentInfo.mainDebtPayment;
    const right = paymentInfo.percentPayment;
    const total = left + right;
    const countLeft = left / total * 100;
    return `<progress value="${countLeft}" max="100"></progress>`
}).join("")}
</div>
`);
};

export { printCalculationResult };