import { Card, CardContent } from "@mui/material";
import { BarChart } from "@mui/x-charts";

const FishChartFilterable: React.FC<{}> = ({ }) => {
    const chartSetting = {
        yAxis: [
            {
                label: 'Fish and Feeds Sales',
            },
        ],
        height: 330,
    };
    const dataset = [
        {
            fish: 59,
            feed: 45,
            month: 'Jan',
        },
        {
            fish: 50,
            feed: 35,
            month: 'Fev',
        },
        {
            fish: 47,
            feed: 65,
            month: 'Mar',
        },
        {
            fish: 54,
            feed: 35,
            month: 'Apr',
        },
        {
            fish: 45,
            feed: 65,
            month: 'May',
        },
        {
            fish: 60,
            feed: 63,
            month: 'June',
        },
        {
            fish: 30,
            feed: 45,
            month: 'July',
        },
        {
            fish: 32,
            feed: 50,
            month: 'Aug',
        },
        {
            fish: 80,
            feed: 65,
            month: 'Sept',
        },
        {
            fish: 45,
            feed: 75,
            month: 'Oct',
        },
        {
            fish: 55,
            feed: 70,
            month: 'Nov',
        },
        {
            fish: 80,
            feed: 35,
            month: 'Dec',
        },
    ];

    const valueFormatter = (value: number) => `${value}mm`;

    return (
        <Card sx={{ minWidth: 275, minHeight: 374 }} className="card w-100">
            <CardContent>
                <BarChart
                    className="w-100"
                    dataset={dataset}
                    xAxis={[{ scaleType: 'band', dataKey: 'month' }]}
                    series={[
                        { dataKey: 'fish', label: 'Purchase', valueFormatter },
                        { dataKey: 'feed', label: 'Sales', valueFormatter }
                    ]}
                    {...chartSetting}
                />
            </CardContent>
        </Card>
    )
}

export default FishChartFilterable;