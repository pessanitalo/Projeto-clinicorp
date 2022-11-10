export function parseDate(dateToParse: Date | string): Date {
    if (dateToParse) {
        let dateToSplit = dateToParse;
        let arrayDate = dateToSplit.toString().split("/");
        dateToSplit = arrayDate[2] + '-' + arrayDate[1] + '-' + arrayDate[0];

        return new Date(dateToSplit);
    }
    else
        return null!;
}