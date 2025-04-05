import { PaymentInfo } from ".";

type CalculationResult = {
    payment?: number;
    sumPayment: number;
    sumMainDebtPayment: number;
    sumPercentPayment: number;
    mainDebtInPercent: number;
    percentsInPercent: number;
    paymentInfos: PaymentInfo[];
}

export default CalculationResult;