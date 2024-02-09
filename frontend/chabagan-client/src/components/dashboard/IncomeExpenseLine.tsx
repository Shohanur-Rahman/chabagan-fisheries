import { Card, CardContent } from "@mui/material";
import { LineChart } from "@mui/x-charts";

const IncomeExpenseLine: React.FC<{}> = ({ }) => {

    const income = [0, 3000, 2000, 2780, 1890, 2390, 3490];
    const expense = [0, 1398, 3800, 3908, 4800, 3800, 4300];
    const xLabels = [
        'Jan',
        'Feb',
        'Mar',
        'Apr',
        'May',
        'June',
        'July',
    ];

    return (
        <Card sx={{ minWidth: 275, minHeight: 374 }} className="card w-100">
            <CardContent>
                <LineChart
                    width={500}
                    height={300}
                    series={[
                        { data: income, label: 'Income' },
                        { data: expense, label: 'Expense' },
                    ]}
                    xAxis={[{ scaleType: 'point', data: xLabels }]}
                />
            </CardContent>
        </Card>
    )
}

export default IncomeExpenseLine;