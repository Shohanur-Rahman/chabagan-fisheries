import { BarChart } from '@mui/x-charts/BarChart';
import { PieChart, pieArcLabelClasses } from '@mui/x-charts';
import { useEffect } from 'react';
import { IconBreadcrumbs } from '../../components/common/IconBreadcrumbs';
import dashboarBreadCrumb from '../../data/Breadcrumbs';
import { ProjectTitle } from '../../data/Config';
import { Box, Card, CardContent, Grid } from '@mui/material';

export default function Dashboard() {

    const chartSetting = {
        yAxis: [
            {
                label: 'Fish and Feeds Sales',
            },
        ],
        height: 300,
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


    const data = [
        { value: 5, label: 'A' },
        { value: 10, label: 'B' },
        { value: 15, label: 'C' },
        { value: 20, label: 'D' },
    ];

    const size = {
        height: 300,
    };

    const valueFormatter = (value: number) => `${value}mm`;

    useEffect(() => {
        document.title = `Dashboard | ${ProjectTitle}`;
    }, []);
    return (
        <>
            <IconBreadcrumbs props={dashboarBreadCrumb.dashboarBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardContent>
                                <BarChart
                                    className="w-100"
                                    dataset={dataset}
                                    xAxis={[{ scaleType: 'band', dataKey: 'month' }]}
                                    series={[
                                        { dataKey: 'fish', label: 'Fish', valueFormatter },
                                        { dataKey: 'feed', label: 'Feeds', valueFormatter }
                                    ]}
                                    {...chartSetting}
                                />
                            </CardContent>
                        </Card>
                    </Grid>

                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
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
                    </Grid>

                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardContent>
                                <PieChart
                                    series={[
                                        {
                                            arcLabel: (item) => `${item.label} (${item.value})`,
                                            arcLabelMinAngle: 45,
                                            data,
                                        },
                                    ]}
                                    sx={{
                                        [`& .${pieArcLabelClasses.root}`]: {
                                            fill: 'white',
                                            fontWeight: 'bold',
                                        },
                                    }}
                                    {...size}
                                />
                            </CardContent>
                        </Card>
                    </Grid>

                    <Grid item xs={12} sm={6} md={6} lg={6}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardContent>
                                <PieChart
                                    series={[
                                        {
                                            arcLabel: (item) => `${item.label} (${item.value})`,
                                            arcLabelMinAngle: 45,
                                            data,
                                        },
                                    ]}
                                    sx={{
                                        [`& .${pieArcLabelClasses.root}`]: {
                                            fill: 'white',
                                            fontWeight: 'bold',
                                        },
                                    }}
                                    {...size}
                                />
                            </CardContent>
                        </Card>
                    </Grid>

                </Grid>
            </Box>
        </>
    )
}